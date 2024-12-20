import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {
  constructor(
    private swal: SwalService
  ) { }
  
  errorHandler(err:HttpErrorResponse){
    console.log(err);
    
    if(err.status==500){
        let errorMessage=""
        for (const e of err.error.errorMessages) {
          errorMessage+= e + "\n"
          this.swal.callToast(errorMessage,"error")
        }
    }
  }

  }

