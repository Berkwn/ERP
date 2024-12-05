import { CustomerModel } from "./customer.model";
import { OrderDetailModel } from "./order-detail.model";

export class OrderModel{
    id:string=""
    orderNumber:number=0;
    orderNumberYear:number=0;
    number:string="";
    customerId:string="";
    date:string="";
    deliveryDate:string="";
    customer:CustomerModel=new CustomerModel();
    status:OrderstatusEnum=new OrderstatusEnum();
    orderDetails:OrderDetailModel[]=[];
}

export class OrderstatusEnum{
    value:number=1;
    name:string="";
    
}