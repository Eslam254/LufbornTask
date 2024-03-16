import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ProductService } from './ProductService';
import { AddProductComponent } from './Product/add-product/add-product.component';
import { CommonModule, formatDate } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent  implements OnInit{
  Products: any[] = [];
  counter: number = 1;
  ProductsName:any='';
  p: any = 1;
  count: any = 3;
  constructor(
    private router: Router,
    private modalService : NgbModal,

    private productsService: ProductService,
  ) {}
  ngOnInit() {
    let names = '';
      
    for (let i = 0; i < this.Products.length; i++) {
    
      names += this.Products[i].name;
    
      if (i < this.Products.length - 1) {
    
        names += ', ';
      }
    }

    this.ProductsName = names;
    this.getProducts();
  }
  title = 'project';
  getProducts()
  {
    debugger;
    this.productsService.getProduct().subscribe((data: Object) => {
      this.Products = data as any[]; 
      this.Products.forEach(element => {
      console.log(this.Products)
      });
     
    });

  }
  modal(){
    const modalRef = this.modalService.open(AddProductComponent, { size: 'lg', backdrop: 'static' , centered: true});
    modalRef.hidden.subscribe(() => {
      this.getProducts();
     })
  }
  Edit(id : string){

    const modalRef = this.modalService.open(AddProductComponent, { size: 'lg', backdrop: 'static' , centered: true});
    modalRef.componentInstance.branchId=id
    modalRef.hidden.subscribe(() => {
      this.getProducts();
     })  }
  softDeleteBranch(id : string){
    this.productsService.getProductById(id).subscribe(e=>
    {
      const Branch : any= e 
      Branch.isDeleted = true 
      this.productsService.updateProduct(Branch).subscribe(e=>{
        this.getProducts()
      })
    })
  }
  deleteBranch(id: string) {
    const confirmDelete = confirm(
      'Are you sure you want to delete this Branch?'
    );
    this.productsService.deleteProduct(id).subscribe(
      (response: any) => {
        console.log('Branch deleted successfully:', response);
        location.reload();
      },
      (error: any) => {
        console.error('Failed to delete Branch:', error);
      }
    );
  }
}
