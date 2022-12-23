import { Item } from "./item";

export interface Revenue {
    rev_Id: number;
    item_Id: number;
    rev_Desc: string;
    rev_Amount: string;
    rev_By: string;
    rev_Date: Date | null;
    rev_Month_Year: string;
    finalized: boolean;
    //item: Item;
}