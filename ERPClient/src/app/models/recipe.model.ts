import { ProductModel } from "./product.model";
import { RecipeDetailModel } from "./Recipe-detail.model";

export class RecipeModel{
    id:string="";
    productId:string="";
    product:ProductModel =new ProductModel();
    recipeDetails:RecipeDetailModel[]=[];
}