export class MenuModel{
    name:string="";
    icon:string="";
    url:string="";
    isTitle:boolean=false;
    subMenus:MenuModel[]=[];

}

export const Menus: MenuModel[]=[
    {
        name:"Anasayfa",
        icon:"fas fa-solid fa-home",
        url:"/",
        isTitle:false,
        subMenus:[]
    },
    {
        name:"Ana Grup",
        icon:"fas fa-solid fa-group",
        url:"",
        isTitle:false,
        subMenus:[
            {
                name:"Müşteriler",
                icon:"fas fa-solid fa-users me-2",
                url:"/customers",
                isTitle:false,
                subMenus:[]
            },
            {
                name:"Depolar",
                icon:"fa-solid fa-laptop me-2",
                url:"/depots",
                isTitle:false,
                subMenus:[]
            },
            {
                name:"Ürünler",
                icon: "fa-solid fa-product-hunt me-2",
                url:"/products",
                isTitle:false,
                subMenus:[]
            },
            {
                name:"Reçeteler",
                icon:"",
                url:"/recipes",
                isTitle:false,
                subMenus:[
                 
                ]
            },
            {
                name:"Siparişler",
                icon: "fa-solid fa-product-hunt me-2",
                url:"/order",
                isTitle:false,
                subMenus:[]
            },
        ]

    }

]