import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";
import RevenueDetailedChat from "../dashboard/RevenueDetailedChat";
import RevenueDetailedHeader from "./RevenueDetailedHeader";
import RevenueDetailedInfo from "./RevenueDetailedInfo";
import RevenueDetailedSidebar from "./RevenueDetailedSidebar";

export default observer(function RevenueDetails() {
  const { revenueStore } = useStore();
  const {
    selectedRevenue: revenue,
    loadRevenue,
    loadingInitial,
  } = revenueStore;

  const { id } = useParams();

  useEffect(() => {
    if (id) loadRevenue(id);
  }, [id, loadRevenue]);

  if (loadingInitial || !revenue) return <LoadingComponent />;
  return (
    <Grid>
      <Grid.Column width={10}>
        <RevenueDetailedHeader revenue={revenue} />
        <RevenueDetailedInfo revenue={revenue} />
        <RevenueDetailedChat />
      </Grid.Column>
      <Grid.Column width={6}>
        <RevenueDetailedSidebar/>
        </Grid.Column>
    </Grid>
  );
});
