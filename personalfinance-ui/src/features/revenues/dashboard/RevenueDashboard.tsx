import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import RevenueList from "./RevenueList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponent";

export default observer(function RevenueDashboard() {
  const { revenueStore } = useStore();
  const { loadRevenues, revenueRegistry } = revenueStore;
  //const { selectedRevenue, editMode } = revenueStore;

  useEffect(() => {
    if (revenueRegistry.size <= 1) loadRevenues();
  }, [loadRevenues, revenueRegistry.size]);

  if (revenueStore.loadingInitial)
    return <LoadingComponent content="loading app" />;

  return (
    <Grid>
      <Grid.Column width="10">
        <RevenueList />
      </Grid.Column>
      <Grid.Column width="6">
        <h2>
        REvenue Filters</h2>
        </Grid.Column>
    </Grid>
  );
});
