import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../modules/shared.module';
import { RecipeModel } from '../../models/recipe.model';
import { NgForm } from '@angular/forms';
import { ProductModel } from '../../models/product.model';
import { AuthService } from '../../services/auth.service';
import { SwalService } from '../../services/swal.service';
import { HttpService } from '../../services/http.service';
import { RecipeDetailModel } from '../../models/Recipe-detail.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-recipe',
  standalone: true,
  imports: [SharedModule,RouterLink],
  templateUrl: './recipe.component.html',
  styleUrl: './recipe.component.css'
})
export class RecipeComponent implements OnInit {
  recipes: RecipeModel[] = [];
  search:string = "";
  products: ProductModel[] = [];
  semiProducts: ProductModel[] = [];

  detail: RecipeDetailModel = new RecipeDetailModel();



  createModel:RecipeModel = new RecipeModel();
  updateModel:RecipeModel = new RecipeModel();

  constructor(
    private http: HttpService,
    private swal: SwalService
  ){}

  ngOnInit(): void {
    this.getAll();
    this.getAllProducts();
  }

  getAll(){
    this.http.post<RecipeModel[]>("Recipe/GetAll",{},(res)=> {
      this.recipes = res;
    });
  }

  getAllProducts(){
    this.http.post<ProductModel[]>("Product/GetAll",{},(res)=> {
      this.products = res;
      this.semiProducts = res.filter(p=> p.type.value == 2);
    })
  }

  addDetail(){
    const product = this.products.find(p=> p.id == this.detail.productId);
    if(product){
      this.detail.product = product;
    }    

    this.createModel.recipeDetails.push(this.detail);

    this.detail = new RecipeDetailModel();
  }

  removeDetail(index:number){
    this.createModel.recipeDetails.splice(index,1);
  }

  create(form: NgForm){
    if(form.valid){
      this.http.post<string>("Recipe/Create",this.createModel,(res)=> {
        this.swal.callToast(res);
        this.createModel = new RecipeModel();
    
        this.getAll();
      });
    }
  }

  deleteById(model: RecipeModel){
    this.swal.callSwal("Reçeteyi Sil?",`${model.product.name} ürüne ait reçeti silmek istiyor musunuz?`,()=> {
      this.http.post<string>("Recipe/DeleteById",{id: model.id},(res)=> {
        this.getAll();
        this.swal.callToast(res,"info");
      });
    })
  }  
}
