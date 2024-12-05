import { Component, OnInit } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { NgForm } from '@angular/forms';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';
import { CustomerModel } from '../../models/customer.model';
import { ProductModel } from '../../models/product.model';
import { OrderDetailModel } from '../../models/order-detail.model';
import { SharedModule } from '../modules/shared.module';
import { DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css',
  providers:[DatePipe]
})
export class OrderComponent implements OnInit{
  constructor(
    private http:HttpService,
    private swal:SwalService,
    private date:DatePipe,
  ){
    
  }
  
 orders:OrderModel[]=[]; 
customers:CustomerModel[]=[];
products:ProductModel[] =[];
details:OrderDetailModel=new OrderDetailModel();
createModel:OrderModel=new OrderModel();
updateModel:OrderModel=new OrderModel();

createDetail:OrderDetailModel=new OrderDetailModel();
updateDetail:OrderDetailModel=new OrderDetailModel();

ngOnInit(): void {
  this.getAll();
  this.getAllCustomer();
  this.getAllProduct();
}

 getAll(){
  this.http.post<OrderModel[]>("Order/GetAll",{},(res)=>{
    this.orders=res;
  })
 }

 getAllCustomer(){
  this.http.post<CustomerModel[]>("Customer/GetAll",{},(res)=>{
    this.customers=res;
  })
 }
 getAllProduct(){
  this.http.post<ProductModel[]>("Product/GetAll",{},(res)=>{
    this.products=res;
  })
 }

 create(form:NgForm){
  console.log(this.createModel)
   this.createModel.date = this.date.transform(new Date(), "yyyy-MM-dd") ?? "";
   this.createModel.deliveryDate = this.date.transform(new Date(), "yyyy-MM-dd") ?? "";
  
  debugger
  if(form.valid){
  debugger;
    this.http.post<string>("Order/Create",this.createModel,(res)=>{
      debugger;
      this.swal.callToast(res,"info")
      this.createModel=new OrderModel();
      
      this.getAll();
    })
  }
 }

 addDetail(){
  
  const a =this.products.find(x=>x.id==this.details.productId)
  console.log(a)
  if(a)
  this.details.product=a;
   this.createModel.orderDetails.push(this.details);
  this.details=new OrderDetailModel();
 }

 removeDetail(index:number){
this.createModel.orderDetails.splice(1,index);
 }
 number:string=""
 delete(model:OrderModel){
   this.number="BD"+model.orderNumberYear+model.orderNumber
  this.swal.callSwal("Depo Sil?",`${model.customer.name} / ${this.number} siparişi silmek istediğinizden emin misiniz`,()=>{
    this.http.post<string>("Order/DeleteById",{id:model.id},(res)=>{
    this.swal.callToast(res,"info")
    this.getAll();
    })
  })

 }

 get(model:OrderModel){
  this.updateModel={...model}
 }

 update(form:NgForm){
  if(form.valid){
   this.http.post<string>("Order/Update",this.updateModel,(res)=>{
    this.swal.callToast(res,"info")
    this.getAll();
   })
  }
 }
}
