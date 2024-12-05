import { Component } from '@angular/core';
import { RequirementModel } from '../../models/requirements-planning.model';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-requirements-planning',
  standalone: true,
  imports: [],
  templateUrl: './requirements-planning.component.html',
  styleUrl: './requirements-planning.component.css'
})
export class RequirementsPlanningComponent {
orderId:string="";
  constructor(
    private activated:ActivatedRoute,
    private http:HttpService
  ){
    this.activated.params.subscribe(res=>{
      this.orderId=res["orderId"]
      this.get();
    })
  }
  data:RequirementModel=new RequirementModel();

get(){
this.http.post<RequirementModel>("Order/RequirementPlanningByOrderId",{OrderId:this.orderId},(res)=>{
this.data=res;
})
}

}
