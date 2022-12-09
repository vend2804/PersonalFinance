import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import RevenueStore from "./revenueStore";
interface Store {
  activityStore: ActivityStore;
  revenueStore: RevenueStore;
}

export const store: Store = {
  activityStore: new ActivityStore(),
  revenueStore: new RevenueStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
