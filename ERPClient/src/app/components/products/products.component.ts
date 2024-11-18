import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../modules/shared.module';
import { ProductModel, ProductTypeEnum, productTypes } from '../../models/product.model';
import { HttpService } from '../../services/http.service';
import { NgForm } from '@angular/forms';
import { SwalService } from '../../services/swal.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent  implements OnInit {

  constructor(
    private http :HttpService,
    private swal:SwalService
  ){
    
  }
  ngOnInit(): void {
    this.getAll();
  }

  products:ProductModel[]=[];
  updateModel:ProductModel=new ProductModel();
  createModel:ProductModel=new ProductModel();

  productEnum=productTypes;


  getAll(){
    this.http.post<ProductModel[]>("Product/GetAll",{},(res)=>{
        this.products=res;
    })
  }


  create(form:NgForm){
    if(form.valid){
this.http.post<string>("Product/Create",this.createModel,(res)=>{
  this.swal.callToast(res,"info")
  this.createModel=new ProductModel();
  this.getAll();
})
    }
  }

  deleteById(model:ProductModel){
this.swal.callSwal("Ürün Sil",`${model.name} adlı ürünü silmek istediğinizden emin misiniz`,()=>{
this.http.post<string>("Product/DeleteById",{id:model.id},(res)=>{
  this.swal.callToast(res,"info")
  this.getAll();
})
})
  }

  get(model:ProductModel){
    this.updateModel={...model}
    this.updateModel.typeValue=model.type.value;
  }

  update(form:NgForm){
    if(form.valid){
      this.http.post<string>("Product/Update",this.updateModel,(res)=>{
        this.swal.callToast(res,"info")
        this.getAll();
      })
    }
  }
}
