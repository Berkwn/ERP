import { Pipe, PipeTransform } from '@angular/core';
import { CustomerModel } from '../models/customer.model';

@Pipe({
  name: 'customer',
  standalone: true
})
export class CustomerPipe implements PipeTransform {

  transform(value:CustomerModel[],search:string):CustomerModel[] {
   
    if(search===""){
      return value;
    }

    return value.filter(x=>x.name.toLocaleLowerCase().includes(search.toLocaleLowerCase()))
  }

}
