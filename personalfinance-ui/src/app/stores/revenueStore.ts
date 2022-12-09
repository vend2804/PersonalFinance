import { makeAutoObservable, runInAction } from "mobx";
import { Revenue } from "../models/revenue";
import agent from "../api/agent";


export default class RevenueStore {
  // activities: Activity[] = [];
  revenueRegistry = new Map<string, Revenue>();
  selectedRevenue: Revenue | undefined = undefined!;
  editMode = false;
  revenueMode = false;

  loading = false;
  loadingInitial = true;


  constructor() {
    makeAutoObservable(this);
  }

  get revenuesByDate() {
    return Array.from(this.revenueRegistry.values()).sort(
      (a, b) => Date.parse(a.rev_Date) - Date.parse(b.rev_Date)
    );
  }
  loadRevenues = async () => {
    //this.setLoadingInitial(true);
    try {
      const revenues = await agent.Revenues.list();

      revenues.forEach((revenue) => {
        revenue.rev_Date = revenue.rev_Date.split("T")[0];
        //this.activities.push(activity);
        this.revenueRegistry.set(revenue.rev_Id, revenue);
      });
      this.setLoadingInitial(false);
      //this.revenueMode = true;
    } catch (error) {
      console.log(error);

      this.setLoadingInitial(false);
     // this.revenueMode = true;
    }
  };

  setLoadingInitial = (state: boolean) => {
    this.loadingInitial = state;
  };

  selectRevenue = (id: string) => {
    // this.selectedActivity = this.activities.find((a) => a.id === id);
    this.selectedRevenue = this.revenueRegistry.get(id);
  };

  cancelSelectedRevenue = () => {
    this.selectedRevenue = undefined!;
  };

  openForm = (id?: string) => {
    id ? this.selectRevenue(id) : this.cancelSelectedRevenue();
    this.editMode = true;
  };

  closeForm = () => {
    this.editMode = false;
  };

  // method for Create Activity using the Stores using MobX

  createRevenue = async (revenue: Revenue) => {
    this.loading = true;
    //revenue.id = uuid();
    try {
      await agent.Revenues.create(revenue);
      runInAction(() => {
        //this.activities.push(activity);
        this.revenueRegistry.set(revenue.rev_Id, revenue);
        this.selectedRevenue = revenue;
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };
  // update functionalitywith MobX
  updateRevenue = async (revenue: Revenue) => {
    this.loading = true;
    try {
      await agent.Revenues.update(revenue);
      runInAction(() => {
        // this.activities = [ ...this.activities.filter((a) => a.id !== activity.id),activity];
        this.revenueRegistry.set(revenue.rev_Id, revenue);
        this.selectedRevenue = revenue;
        //this.activities.push(activity);
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };
  deleteRevenue = async (id: string) => {
    this.loading = true;
    try {
      await agent.Revenues.delete(id.toString());
      // this.activities = [...this.activities.filter((a) => a.id !== id)];
      this.revenueRegistry.delete(id);
      if (this.selectedRevenue?.rev_Id === id) {
        this.cancelSelectedRevenue();
      }

      this.loading = false;
      runInAction(() => {});
    } catch (error) {
      runInAction(() => {
        this.loading = false;
      });
    }
  };
}
