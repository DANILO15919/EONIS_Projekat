import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductServiceService } from 'src/services/product-service.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  products: any[] = [];
  searchText: string = '';
  page: number = 1;
  pageSize: number = 10;
  totalProducts: number = 0;
  sortColumn: string = '';
  sortDirection: string = 'asc';
  nameTEST: string = '';
  filteredProducts1: any[] = [];

  constructor(private productService: ProductServiceService,private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }
  loadProducts(): void {
    this.productService.GetProizvods().subscribe(
      (res: any) => {
        console.log("Entered here");
        console.log(res); 
        this.products = res;
        this.totalProducts = this.products.length;
      },
      (err: any) => {
        console.log(this.products);
        console.error('Failed to fetch products', err);
      }
    );
  }
  

  get filteredProducts(): any[] {
    let filtered = this.products;

    // Search filter
    if (this.searchText) {
      filtered = filtered.filter(product => {
        const productName = product.Naziv ? product.Naziv.toLowerCase() : ''; // Null check
        return productName == this.searchText.toLowerCase();
      });
    }

    // Sort
    if (this.sortColumn) {
      filtered.sort((a, b) => {
        const aValue = a[this.sortColumn];
        const bValue = b[this.sortColumn];
        if (aValue < bValue) return this.sortDirection === 'asc' ? -1 : 1;
        if (aValue > bValue) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
      });
    }

    // Pagination
    const start = (this.page - 1) * this.pageSize;
    const end = start + this.pageSize;
    return filtered.slice(start, end);
  }

  applyFilters(): void {
    // Apply search filter
    const searchTextLowerCase = this.searchText.toLowerCase(); // Convert searchText to lowercase
    const filteredProducts = this.products.filter(product => {
      const productName = product.naziv ? product.naziv.toLowerCase() : ''; // Null check
      return productName == searchTextLowerCase;
    });
  
    // Apply sort filter
    if (this.sortColumn) {
      filteredProducts.sort((a, b) => {
        return a[this.sortColumn] > b[this.sortColumn] ? 1 : -1;
      });
    }
  
  }
  

  searchProducts(searchText: string): void {
    this.searchText = searchText.trim().toLowerCase(); // Convert search text to lowercase
        this.applyFilters(); // Apply filters to update the filtered products
  }

  sortBy(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }
  }

  onPageChange(page: number): void {
    this.page = page;
  }

  handleButtonClick(product: any): void {
    console.log('Button clicked for product:', product);
  }

  get totalPages(): number {
    return Math.ceil(this.totalProducts / this.pageSize);
  }

  goToPayment(product: any): void {
    this.nameTEST = product.naziv;
    this.router.navigate(['/payment', { name: product.naziv, price: product.cena }]);
  }

  logout(): void {
    this.router.navigateByUrl('/login');
  }
}
