import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Articles from "../articles/articles.json"
import ReactMarkdown from "react-markdown";
import rehypeHighlight from 'rehype-highlight'

function Article(props) {
  const { id } = useParams();
  
  const article = Articles.find((article) => article.id === Number(id));
  const [post, setPost] = useState('');

    useEffect(() => {
        import(`../articles/${article.content}`)
            .then(res => {
                fetch(res.default)
                    .then(res => res.text())
                    .then(res => setPost(res))
                    .catch(err => console.log(err));
            })
            .catch(err => console.log(err));
    });
  
  return (
    
    <div className="home">
      <div class="container">
        <div class="row align-items-center my-5">
          <div class="col-lg-12">
            <h1>{article.title}</h1>
            <hr class="line"/>
            <div class="row jfh-summary-meta">
              <div class="col-sm-3">Published: { article.date }</div>
              <div class="col-sm-3">Author: { article.author }</div>
              <div class="col-sm-3">Category: { article.category }</div>
              <div class="col-sm-3">Tags: { article.tags }</div>
            </div>
            <hr class="line"/>
            <div>
              <ReactMarkdown rehypePlugins={[rehypeHighlight]} children = { post } />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Article;