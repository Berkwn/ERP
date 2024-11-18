import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlankComponent } from '../blank/blank.component';
import { SectionComponent } from '../section/section.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,FormsModule,
    BlankComponent,SectionComponent
  ],
  exports:[ 
    CommonModule,FormsModule,
    BlankComponent,SectionComponent

  ]
})
export class SharedModule { }
