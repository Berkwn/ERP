import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { SharedModule } from '../modules/shared.module';
import { CustomerModel } from '../../models/customer.model';
import { HttpService } from '../../services/http.service';
import { CustomerPipe } from '../customer.pipe';
import { NgForm } from '@angular/forms';
import { SwalService } from '../../services/swal.service';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [SharedModule,CustomerPipe],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit{
search:string="";


  customers:CustomerModel[]=[];
  createCustomerModel:CustomerModel=new CustomerModel();
  updateCustomerModel:CustomerModel=new CustomerModel();

  constructor(
    private swal:SwalService,
    private http:HttpService){}
  ngOnInit(): void {
  this.getAllCustomer();
  }
  
  
  getAllCustomer(){
    this.http.post<CustomerModel[]>("Customer/GetAll",{},(res)=>{
      this.customers=res;
    })
  }


  create(form:NgForm){
   
    if(form.valid){
      this.http.post<string>("Customer/Create",this.createCustomerModel,(res)=>{
       this.swal.callToast(res) 
        this.createCustomerModel=new CustomerModel();
        this.getAllCustomer();
      })
    }

  }

  deletebyId(model:CustomerModel){
    this.swal.callSwal("Müşteri sil",`${model.name} müşterisini silmek istiyor musun?`,()=>{
      this.http.post<string>("Customer/Delete",{id:model.id},(res)=>{
        this.swal.callToast(res,"info")
        this.getAllCustomer();
      })
    })
  }
  
  get(model:CustomerModel){
    this.updateCustomerModel={...model};
  }

  update(form:NgForm){
    debugger;
    if(form.valid){
      debugger;
      this.http.post<string>("Customer/Update",this.updateCustomerModel,(res)=>{
        this.swal.callToast(res,"info")
        debugger;
        this.getAllCustomer();
        console.log(this.updateCustomerModel);
      })
    }
  }

  }

