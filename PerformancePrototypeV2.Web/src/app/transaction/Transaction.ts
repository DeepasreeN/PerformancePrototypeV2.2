export interface Transaction {
    id : number;
    date:string;
    time:string;
    quantity:number;
    storeId:number;
    storeLocation:string;
    productId:number;
    unitPrice:number;
    productCategory:string;
    productType:string;
    productDetail:string;
    month:string;
  }

  export interface TransactionResponse{
   transactions:Transaction
    total :number;
    skip:number;
    limit:number;
  }