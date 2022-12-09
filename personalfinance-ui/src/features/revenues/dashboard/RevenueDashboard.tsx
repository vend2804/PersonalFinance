import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import RevenueList from "./RevenueList";
import RevenueDetails from "../details/RevenueDetails";
import RevenueForm from "../form/RevenueForm";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponent";

export default observer(function RevenueDashboard() {
  const { revenueStore } = useStore();
  const { selectedRevenue, editMode } = revenueStore;

  useEffect(() => {
    revenueStore.loadRevenues();
  }, [revenueStore]);

  if (revenueStore.loadingInitial)
    return <LoadingComponent content="loading app" />;

  return (
    <Grid>
      <Grid.Column width="10">
        <RevenueList />
      </Grid.Column>
      <Grid.Column width="6">
        {selectedRevenue && !editMode && <RevenueDetails />}
        {editMode && <RevenueForm />}
      </Grid.Column>
    </Grid>
  );
});
