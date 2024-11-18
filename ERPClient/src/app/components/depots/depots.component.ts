import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../modules/shared.module';
import { DepotsModel } from '../../models/depot.model';
import { HttpService } from '../../services/http.service';
import { NgForm } from '@angular/forms';
import { SwalService } from '../../services/swal.service';
import { ProductsComponent } from '../products/products.component';
import { ProductModel, ProductTypeEnum, productTypes } from '../../models/product.model';

@Component({
  selector: 'app-depots',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './depots.component.html',
  styleUrl: './depots.component.css'
})
export class DepotsComponent implements OnInit{

  constructor(
    private http:HttpService,
    private swal:SwalService
  ){
    
  }
  

 depots:DepotsModel[]=[]; 
 createDepot:DepotsModel=new DepotsModel();
 updateDepot:DepotsModel=new DepotsModel();

ngOnInit(): void {
  this.getAll();
}

 getAll(){
  this.http.post<DepotsModel[]>("Depot/GetAll",{},(res)=>{
    this.depots=res;
  })
 }

 create(form:NgForm){
  debugger
  if(form.valid){
  debugger;
    this.http.post<string>("Depot/Create",this.createDepot,(res)=>{
      this.swal.callToast(res,"info")
      this.createDepot=new DepotsModel();
      this.getAll();
    })
  }
 }



 delete(model:DepotsModel){
  this.swal.callSwal("Depo Sil?",`${model.name} depoyu silmek istediğinizden emin misiniz`,()=>{
    this.http.post<string>("Depot/DeleteById",{id:model.id},(res)=>{
    this.swal.callToast(res,"info")
    this.getAll();
    })
  })

 }

 get(model:DepotsModel){
  this.updateDepot={...model}
 }

 update(form:NgForm){
  if(form.valid){
   this.http.post<string>("Depot/Update",this.updateDepot,(res)=>{
    this.swal.callToast(res,"info")
    this.getAll();
   })
  }
 }
}
