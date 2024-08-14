import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {

  private apiUrl = 'http://localhost:5128/api';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Transaction`);
  }
  getAllTransactions(pageNo:number,pageSize:number): Observable<any> {  
    return this.http.get(this.apiUrl+'/Transaction/page?pageNo=' + pageNo+'&pageSize='+pageSize);  
    
   }  
}
