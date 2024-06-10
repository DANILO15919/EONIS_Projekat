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
        const productName = product.naziv ? product.naziv.toLowerCase() : ''; // Null check
        return productName.includes(this.searchText.toLowerCase());
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
    const searchTextLowerCase = this.searchText.toLowerCase();
    if (searchTextLowerCase) {
      this.filteredProducts1 = this.products.filter(product => {
        const productName = product.Naziv ? product.Naziv.toLowerCase() : '';
        return productName.includes(searchTextLowerCase);
      });
    } else {
      // If search text is empty, reset filteredProducts to all products
      this.filteredProducts1 = this.products;
    }
  
    // Apply sort filter (if needed)
    if (this.sortColumn) {
      this.filteredProducts.sort((a, b) => {
        return a[this.sortColumn] > b[this.sortColumn] ? 1 : -1;
      });
    }
  }
  

  searchProducts(searchText: string): void {
    this.searchText = searchText.trim().toLowerCase();
    this.applyFilters(); // Ensure to apply filters after updating search text
  }
  

  sortBy(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }
  
    this.applyFilters(); // Ensure to apply filters after updating sort column and direction
  }

  onPageChange(page: number): void {
    this.page = page;
  }

  get totalPages(): number {
    return Math.ceil(this.totalProducts / this.pageSize);
  }

  goToPayment(product: any): void {
    this.nameTEST = product.slika;
    this.router.navigate(['/payment', { name: product.naziv, price: product.cena, picture: product.slika }]);
  }

  logout(): void {
    this.router.navigateByUrl('/login');
  }
}
