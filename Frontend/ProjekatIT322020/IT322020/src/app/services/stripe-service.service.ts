import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { loadStripe } from '@stripe/stripe-js';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StripeService {

  private stripePromise = loadStripe(environment.stripe.publishableKey);

  constructor(private http: HttpClient) { }

  async createCheckoutSession(amount: number, productName: string) {
    const session = await this.http.post<any>('https://localhost:7182/api/Payments/create-checkout-session', {
      amount,
      productName
    }).toPromise();

    const stripe = await this.stripePromise;
    await stripe?.redirectToCheckout({ sessionId: session.sessionId });
  }
}
