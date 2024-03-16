import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductService } from '../../ProductService';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.scss'
})
export class AddProductComponent {
  @Input() branchId: string = '';
  productname: string = '';
  isEditMode: boolean = false;
  quantity: string = '';
  price: string = '';
  tax : string = '';
  deliveryCharge : string = '';
  description : string = '';
  Merchanname : string = '';
  cities: any[] = [];
    constructor(
      private route: ActivatedRoute,
      private branchService: ProductService,
      private router: Router,
      private activeModal : NgbActiveModal,
    ){}
    branchesForm =new FormGroup({
      productname:new FormControl('',[Validators.required,Validators.minLength(3)]),
      price:new FormControl('',[Validators.required]),
      quantity:new FormControl('',[Validators.required]),
      tax:new FormControl('',[Validators.required]),
      deliveryCharge:new FormControl('',[Validators.required]),
      description:new FormControl('',[Validators.required]),
      Merchanname:new FormControl('',[Validators.required])
    })
    ngOnInit()  {
      if (this.branchId) {
            this.isEditMode = true;
            this.branchService.getProductById(this.branchId).subscribe((data: any) => {
              this.productname = data.productname;
              this.price = data.price;
              this.quantity = data.quantity;  
              this.tax = data.tax;
              this.deliveryCharge = data.deliveryCharge;
              this.description = data.description;
              this.Merchanname = data.merchanname;
              this.branchesForm.patchValue({
                productname :this.productname,
                price : this.price ,
                quantity : this.quantity, 
                tax : this.tax,
                deliveryCharge : this.deliveryCharge,
                description : this.description,
                Merchanname : this.Merchanname
              })
            });
          }
    }
  submitForm() {
    debugger;
    if(this.branchesForm.valid){
    if (this.isEditMode) {
      const branchData = {
        id: this.branchId!,
        productnme: this.productname,
        quantity: this.quantity,
        price : this.price,
        tax : this.tax,
        description :this.description,
        deliverycharge : this.deliveryCharge,
        merchantname : this.Merchanname
      };
      this.updateBranch(branchData);
    } else {
      const branchData = {
        productname: this.productname,
        quantity: this.quantity,
        price : this.price,
        tax : this.tax,
        description :this.description,
        deliverycharge : this.deliveryCharge,
        merchantname : this.Merchanname
      };
      this.addBranch(branchData);
    }
   this.activeModal.close();
   this.branchService.getProduct();
  }
  }
  close(){
    this.activeModal.close();
 
   }
 
   addBranch(branchData: any) {
     this.branchService.createProduct(branchData).subscribe((data: Object) => {});
   }
   updateBranch(branchData: any) {
    console.log(branchData);
    this.branchService.updateProduct(branchData).subscribe(
      (response: any) => {
      },
      (error: any) => {
        
      }
    );
    console.log(branchData);
  }
 
}
