import {Component} from '@angular/core';
import { Transaction } from './Transaction';
import { TransactionService } from './transactions.service';
import { LazyLoadEvent } from 'primeng/api';
import { TableLazyLoadEvent } from 'primeng/table';

@Component({
    selector:'app-transaction',
    templateUrl:'./transaction.component.html'
})

export class TransactionComponent{
    transactions: Transaction[] = [];
    totalRecords:number=0;
    recordsPerPage :number = 5;
    loading:boolean=false;

    constructor(private transactionservice: TransactionService) { }
   
    loadTransactions($event:TableLazyLoadEvent) { 
        this.loading=true;
        this.transactionservice.getAllTransactions($event.first|| 0, this.recordsPerPage).subscribe({
            next:(response) => {  
                this.transactions = response.data;  
                this.getTotalCount(); 
                this.loading=false;        
        },
            error:(error) => {
            console.error('Error fetching transaction data', error);
            this.loading=false;
        }
    })  
    }  

    getTotalCount()  {  
        this.transactionservice.getTotalDataCount().subscribe((response: any) => {  
            this.totalRecords = response.data;          
        }) 
    }
  
}