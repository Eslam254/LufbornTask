import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})

export class ProductService 
{
    baseURL: string = 'https://localhost:5001/StoreProduct';

    constructor(private http: HttpClient) {}

    createProduct(model: any) {
      return this.http.post(this.baseURL, model, { headers: this.getHeaders() });
    }

    getProduct() {
        debugger
        return this.http.get(this.baseURL, { headers: this.getHeaders() });
      }
    
      updateProduct(branchData: any) {
        const url = `${this.baseURL}/${branchData.id}`;
        return this.http.put(url, branchData, {
          headers: this.getHeaders()
        });
      }
      getProductById(id: string) {
        const url = `${this.baseURL}/${id}`;
        return this.http.get(url, { headers: this.getHeaders() });
      }
      deleteProduct(id: string) {
        return this.http.delete(`https://localhost:5001/StoreProduct?Id=${id}`, {
          headers: this.getHeaders()
        });
      }


    private getHeaders(): HttpHeaders {
        return new HttpHeaders({
          'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': '*'
        });
      }
}   