import React from "react";
import { Link } from "react-router-dom";
import moment from "moment"

function ArticleSummary(props) {
  return (
    <div class="container-fluid container-article pt-5">
      <div class="panel panel-default">
        <div class="panel-body">
          <h2 class="jfh-header">
          <Link class="nav-link" to={"/article/" + props.id}>{ props.title }</Link>
          </h2>
          <p>{props.summary}</p>
          <hr class="line" />
          <div class="row jfh-summary-meta">
            <div class="col-sm-3">Published: {moment(props.date).format("DD MMMM YYYY")}</div>
            <div class="col-sm-3">Author: {props.author}</div>
            <div class="col-sm-3">Category: {props.category}</div>
            <div class="col-sm-3">Tags: {props.tags}</div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ArticleSummary;