import React from "react";
import {  Header } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import RevenueListItem from './RevenueListItem';

export default observer(function RevenueList() {
  const { revenueStore } = useStore();

  const { groupedRevenues } = revenueStore;

  return (
    <>
      {groupedRevenues.map(([group, revenues]) => (
        <React.Fragment key={group}>
          <Header sub color="teal">
            {group}
          </Header>

          {revenues.map((revenue) => (
            <RevenueListItem key={revenue.rev_Id} revenue={revenue} />
          ))}
        </React.Fragment>
      ))}
    </>
  );
});
