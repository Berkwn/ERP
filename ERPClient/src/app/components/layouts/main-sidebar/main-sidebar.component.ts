import { Component } from '@angular/core';
import { Menus } from '../../../menu';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MenuPipe } from '../../menu.pipe';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';



@Component({
  selector: 'app-main-sidebar',
  standalone: true,
  imports: [RouterLink,RouterLinkActive,MenuPipe,FormsModule],
  templateUrl: './main-sidebar.component.html',
  styleUrl: './main-sidebar.component.css'
})
export class MainSidebarComponent {

  constructor(
    public auth:AuthService
  ){

  }
  
search:string="";
  menus=Menus;
}
