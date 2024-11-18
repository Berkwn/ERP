import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
@Injectable({
  providedIn: 'root'
})
export class SwalService {

  constructor(
 
  ) { }

  callToast(title:string,icon:SweetAlertIcon="success"){
  Swal.fire({
    title:title,
    text:"",
    timer:3000,
    showConfirmButton:false,
    position:'bottom-right',
    icon:icon,
    toast:true,

  });
  }

  callSwal(title:string,text:string,callback:()=>void,icon:SweetAlertIcon="success"){
    Swal.fire({
      title:title,
      text:text,
      icon:icon,
      showConfirmButton:true,
      showCancelButton:true,
      confirmButtonText:"Sil",
      cancelButtonText:"Vazgeç"
    }).then(res=>{

      if(res.isConfirmed){
        callback();
      }
    })
    
    

  }
}
  export type SweetAlertIcon = 'success' | 'error' | 'warning' | 'info' | 'question'