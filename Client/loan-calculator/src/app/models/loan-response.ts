export interface LoanResponse {
  totalAmount: number;
  baseInterest: number;
  additionalInterest: number;
  details: { calculation: string; amount: number }[];
}
