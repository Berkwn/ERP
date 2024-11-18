import { Pipe, PipeTransform } from '@angular/core';
import { MenuModel } from '../menu';

@Pipe({
  name: 'menu',
  standalone: true
})
export class MenuPipe implements PipeTransform {

  transform(value: MenuModel[], search:string): MenuModel[] {
    if(search===""){
      return value;
    }

    return value.filter(x=>x.name.toLocaleLowerCase().includes(search.toLowerCase()))
  }

}
