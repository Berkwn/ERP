import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../modules/shared.module';
import { RecipeDetailModel } from '../../models/Recipe-detail.model';
import { ProductModel } from '../../models/product.model';
import { SwalService } from '../../services/swal.service';
import { HttpService } from '../../services/http.service';
import { ActivatedRoute } from '@angular/router';
import { RecipeModel } from '../../models/recipe.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-recipe-details',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './recipe-details.component.html',
  styleUrl: './recipe-details.component.css'
})
export class RecipeDetailsComponent implements OnInit{

  recipe: RecipeModel=new RecipeModel();
  products:ProductModel[]=[];
  recipeId:string="";
  isUpdateFormActive:boolean=false;

  createModel:RecipeDetailModel=new RecipeDetailModel();
  updateModel:RecipeDetailModel=new RecipeDetailModel();

  constructor(
    private swal:SwalService,
    private http:HttpService,
    private activated:ActivatedRoute

  ){
  this.activated.params.subscribe(res=>{
    this.recipeId=res["id"];
    this.getRecipeId();
    this.createModel.recipeId=this.recipeId;
  })

  }
  ngOnInit(): void {
    this.getAllProducts();

  }

  getRecipeId(){
    this.http.post<RecipeModel>("RecipeDetail/GetByIdWithDetails",{recipeId:this.recipeId},(res)=>{
      this.recipe=res;
    })
  }

  getAllProducts(){
    this.http.post<ProductModel[]>("Product/GetAll",{},(res)=>{
      this.products=res.filter(x=>x.type.value==2)
    })
  }

  create(form:NgForm){
    if(form.valid){

      this.http.post<string>("RecipeDetail/Create",this.createModel,(res)=>{
        this.swal.callToast(res);
        this.createModel=new RecipeDetailModel();
        this.createModel.recipeId=this.recipeId;
        this.getRecipeId();
      })
    }
  }

  deleteById(model:RecipeDetailModel){
    this.swal.callSwal("Reçetedeki ürünü sil",`${model.product.name} ürününü silmek istiyor musunuz`,()=>{
      this.http.post<string>("RecipeDetail/DeleteRecipeWithDetails",{model:model.id},(res)=>{
        this.getRecipeId();
        this.swal.callToast(res,"info")
    })
  })
     
  }

  get(model:RecipeDetailModel){
    this.updateModel={...model};
    this.updateModel.product=this.products.find(x=>x.id==this.updateModel.productId) ?? new ProductModel();
    this.isUpdateFormActive=true;
  }
  update(form:NgForm){
    if(form.valid){
      this.http.post<string>("RecipeDetail/UpdateRecipeWithDetails",this.updateModel,(res)=>{
        this.swal.callToast(res,"info");
        this.getRecipeId();
        this.isUpdateFormActive=false;
      })
    }
  }

}
