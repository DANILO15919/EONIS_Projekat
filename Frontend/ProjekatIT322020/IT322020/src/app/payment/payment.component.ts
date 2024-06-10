import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StripeService } from 'src/app/services/stripe-service.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit{

  productName: string | null = '';
  productPrice: number | null = null;
  productImage: string | null = '';

  constructor(private stripeService: StripeService,private route: ActivatedRoute,private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.productName = params.get('name');
      this.productPrice = +params.get('price')!;
      this.productImage = params.get('picture');
    });
  }

  async handlePayment() {
    await this.stripeService.createCheckoutSession(this.productPrice!*100, this.productName!); // Amount in cents
  }

  navigateToDestination(): void {
    this.router.navigateByUrl('/home');
  }
}
