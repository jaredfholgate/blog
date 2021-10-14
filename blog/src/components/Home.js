import React from "react";
import Articles from "../articles/articles.json"
import ArticleSummary from "./ArticleSummary";

function Home() {
  return (
    <div className="home">
      <div class="container">
        <div class="row align-items-center my-2">
          <div class="col-lg-12">
            <h1 class="font-weight-light">Home</h1>
            <p>
              {
                Articles.sort((item1,item2) => { if(item1.date > item2.date) { return -1; } if(item1.date < item2.date) { return 1; } return 0; }).map((item) => ArticleSummary(item))
              }
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Home;