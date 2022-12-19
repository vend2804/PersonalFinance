import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import RevenueStore from "./revenueStore";
import CommonStore from "./commonStore";
interface Store {
  activityStore: ActivityStore;
  revenueStore: RevenueStore;
  commonStore: CommonStore;
}

export const store: Store = {
  activityStore: new ActivityStore(),
  revenueStore: new RevenueStore(),
  commonStore: new CommonStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
