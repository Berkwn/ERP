export class ResultModel<T>{
    data?:T;
    errorMessage?:string="";
    isSuccesfull:boolean=false;
}