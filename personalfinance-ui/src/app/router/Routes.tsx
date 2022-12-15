import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import RevenueDashboard from "../../features/revenues/dashboard/RevenueDashboard";
import ActivityForm from "../../features/activities/form/ActivityForm";
import RevenueForm from "../../features/revenues/form/RevenueForm";
import ActivityDetails from "../../features/activities/details/ActivityDetails";
import RevenueDetails from "../../features/revenues/details/RevenueDetails";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      //{ path: "", element: <HomePage /> },
      { path: "activities", element: <ActivityDashboard /> },
      { path: "activities/:id", element: <ActivityDetails /> },
      { path: "createActivity", element: <ActivityForm  key='create'/> },
      { path: "manage/:id", element: <ActivityForm  key='manage'/> },
      { path: "revenues", element: <RevenueDashboard /> },
      { path: "revenues/:id", element: <RevenueDetails /> },

      { path: "createRevenue", element: <RevenueForm key='createrev' /> },
      { path: "managerevenues/:id", element: <RevenueForm  key='managerevenue'/> },
    ],
  },
];
export const router = createBrowserRouter(routes);
