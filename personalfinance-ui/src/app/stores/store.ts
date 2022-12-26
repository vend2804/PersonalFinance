import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import RevenueStore from "./revenueStore";
import CommonStore from "./commonStore";
import UserStore from './userStore';
import ModalStore from './modalStore';
interface Store {
  activityStore: ActivityStore;
  revenueStore: RevenueStore;
  commonStore: CommonStore;
  userStore: UserStore;

  modalStore: ModalStore;
}

export const store: Store = {
  activityStore: new ActivityStore(),
  revenueStore: new RevenueStore(),
  commonStore: new CommonStore(),
  userStore : new UserStore(),
  modalStore: new ModalStore()
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
