import { Item } from "./item";

export interface Expense {
  exp_Id: number;
  item_Id: number;
  exp_Desc: string;
  exp_Amount: number;
  exp_By: number;
  exp_Date: string;
  exp_Month_Year: string;
  finalized: boolean;
  item: Item;
}
