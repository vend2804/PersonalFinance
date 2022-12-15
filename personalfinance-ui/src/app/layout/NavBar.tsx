import React from "react";
import { Container, Menu, Button } from "semantic-ui-react";
import { NavLink } from "react-router-dom";

export default function NavBar() {


  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header as={NavLink} to="/">
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: "10px" }}
          />
          Reactivities
        </Menu.Item>
        <Menu.Item as={NavLink} to="/activities" name="Activities" />
        <Menu.Item>
          <Button
           as={NavLink} to='/createActivity'
            positive
            content="Create Activity"
          />
        </Menu.Item>
        <Menu.Item as={NavLink} to="/revenues" name="Revenues" />
        <Menu.Item>
          <Button
            as={NavLink} to='/createRevenue'
            positive
            content="Add Revenue"
          />
        </Menu.Item>
        <Menu.Item as={NavLink} to="/expenses" name="Expenses" />
        <Menu.Item>
          <Button
           as={NavLink} to='/createExpense'
            positive
            content="Add Expense"
          />
        </Menu.Item>
      </Container>
    </Menu>
  );
}
