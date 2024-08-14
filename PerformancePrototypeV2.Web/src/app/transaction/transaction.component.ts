import {Component,OnInit} from '@angular/core';
import { Transaction } from './Transaction';
import { TransactionService } from './transactions.service';

@Component({
    selector:'app-transaction',
    templateUrl:'./transaction.component.html'
})

export class TransactionComponent implements OnInit{
    transactions: Transaction[] = [];
    first:number=0;
    last:number=0;
    totalrescords:number=0;
    pageNo:number=0;
    recordsPerPage :number =0;
    loading:boolean=false;
    data: any;

    constructor(private transactionservice: TransactionService) { }

    ngOnInit(){
        this.loadData();
    }

    loadData()
    {   this.loading=true;
        this.transactionservice.getData().subscribe({
           next: (response) => {
                this.transactions = response.data;
                this.loading=false;
            },
            error:(error) => {
                console.error('Error fetching transaction data', error);
                this.loading=false;
            }
        });
    }

    getAllTransactaions() {  
        this.transactionservice.getAllTransactions(this.pageNo, this.recordsPerPage).subscribe((data: any) => {  
            this.transactions = data;  
            //this.getAllCompaniesCount();          
        })  
    }  

    pageChange($event:any)
    {

    }

}