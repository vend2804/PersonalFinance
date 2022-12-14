import { createBrowserRouter, Navigate, RouteObject } from "react-router-dom";
import App from "../layout/App";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import RevenueDashboard from "../../features/revenues/dashboard/RevenueDashboard";
import ActivityForm from "../../features/activities/form/ActivityForm";
import RevenueForm from "../../features/revenues/form/RevenueForm";
import ActivityDetails from "../../features/activities/details/ActivityDetails";
import RevenueDetails from "../../features/revenues/details/RevenueDetails";
import TestErrors from "../../features/errors/TestError";
import NotFound from "../../features/errors/NotFound";
import ServerError from "../../features/errors/ServerError";
import LoginForm from "../../features/users/LoginForm";
import ProfilePage from "../../features/profiles/ProfilePage";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      //{ path: "", element: <HomePage /> },
      { path: "activities", element: <ActivityDashboard /> },
      { path: "activities/:id", element: <ActivityDetails /> },
      { path: "createActivity", element: <ActivityForm key="create" /> },
      { path: "manage/:id", element: <ActivityForm key="manage" /> },
      { path: "profiles/:username", element: <ProfilePage /> },
      { path: "login", element: <LoginForm key="login" /> },
      { path: "revenues", element: <RevenueDashboard /> },
      { path: "revenues/:id", element: <RevenueDetails /> },

      { path: "createRevenue", element: <RevenueForm key="createrev" /> },
      {
        path: "managerevenues/:id",
        element: <RevenueForm key="managerevenue" />,
      },
      { path: "errors", element: <TestErrors /> },
      { path: "not-found", element: <NotFound /> },
      { path: "server-error", element: <ServerError /> },
      { path: "*", element: <Navigate replace to="/not-found" /> },
    ],
  },
];
export const router = createBrowserRouter(routes);
