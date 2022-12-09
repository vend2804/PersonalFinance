import { Category } from "./category";
export interface Item {
  item_Id: number;
  item_Name: string;
  item_Desc: string;
  created_By: string;
  entry_Date: string;
  isActive: boolean;
  cat_Id: number;
  category: Category;
}
