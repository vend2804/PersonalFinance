import { Item } from "./item";

export interface Revenue {
    rev_Id: string;
    item_Id: string;
    rev_Desc: string;
    rev_Amount: string;
    rev_By: string;
    rev_Date: string;
    rev_Month_Year: string;
    finalized: string;
    //item: Item;
}