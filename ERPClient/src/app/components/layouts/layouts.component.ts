import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { MainSidebarComponent } from './main-sidebar/main-sidebar.component';
import { ControlSidebarComponent } from './control-sidebar/control-sidebar.component';
import { BlankComponent } from '../blank/blank.component';
import { SectionComponent } from '../section/section.component';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [RouterOutlet,NavbarComponent,FooterComponent,MainSidebarComponent,ControlSidebarComponent],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css'
})
export class LayoutsComponent {

}
