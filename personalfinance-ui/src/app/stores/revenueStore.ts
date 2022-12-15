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
    this.setLoadingInitial(true);
    try {
      const revenues = await agent.Revenues.list();

      revenues.forEach((revenue) => {
        this.setRevenue(revenue);
      });
      this.setLoadingInitial(false);
      //this.revenueMode = true;
    } catch (error) {
      console.log(error);

      this.setLoadingInitial(false);
      // this.revenueMode = true;
    }
  };
  loadRevenue = async (id: string) => {
    let revenue = this.getRevenue(id);
    if (revenue) {
      this.selectedRevenue = revenue;
      return revenue;
    } else {
      this.setLoadingInitial(true);
      try {
        revenue = await agent.Revenues.details(id);
        this.setRevenue(revenue);
        runInAction(() => {
          this.selectedRevenue = revenue;
        });

        this.setLoadingInitial(false);
        return revenue;
      } catch (error) {
        console.log(error);
        this.setLoadingInitial(false);
      }
    }
  };

  private setRevenue = (revenue: Revenue) => {
    revenue.rev_Date = revenue.rev_Date.split("T")[0];
    //this.activities.push(activity);
    this.revenueRegistry.set(revenue.rev_Id, revenue);
  };
  private getRevenue = (id: string) => {
    return this.revenueRegistry.get(id);
  };

  setLoadingInitial = (state: boolean) => {
    this.loadingInitial = state;
  };

  // method for Create Activity using the Stores using MobX

  createRevenue = async (revenue: Revenue) => {
    this.loading = true;
    //revenue.rev_Id =1 //revenue.rev_Id;
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
      await agent.Revenues.delete(id);
      // this.activities = [...this.activities.filter((a) => a.id !== id)];
      runInAction(() => {
        this.revenueRegistry.delete(id);
        this.loading = false;
      });
    } catch (error) {
      runInAction(() => {
        this.loading = false;
      });
    }
  };
}
