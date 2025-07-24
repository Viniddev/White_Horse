import { useState } from "react";
import { IPostsInformations } from "@/@types/IPostsInformations";
import { IPostElements } from "@/@types/IPostsElements";

import "./postsStyles.scss";
import { POSTS } from "@/utils/frontEndUrls/urls";

export default function Post(element: IPostElements) {

    const [informations, setInformations] = useState<IPostsInformations>(element.element);

    return (
      <div className="cardPost">
        <div className="postBody" id="postHeader">
          <h1 className="titlePost">{informations.topic}</h1>
        </div>

        <hr className="postDivision" />

        <div className="postBody">
          <p className="conteudoPost">{informations.content}</p>

          <div className="sessaoInterativa">
            <div className="flexRow interactButtons" id="like">
              <p className="statistics">{informations.likes}</p>
              <i
                className="pi pi-thumbs-up-fill"
                style={{ fontSize: "1rem", color: "green" }}
              ></i>
            </div>
            <div className="flexRow interactButtons" id="deslike">
              <p className="statistics">{informations.deslikes}</p>
              <i
                className="pi pi-thumbs-down-fill"
                style={{ fontSize: "1rem", color: "red" }}
              ></i>
            </div>
            <a href={POSTS(informations.id)} className="linkPost">
              <div className="flexRow sessaoComentarios">
                <p className="informativo">Participe dos comentários</p>
                <i
                  className="pi pi-reply"
                  style={{ fontSize: "1rem", color: "red" }}
                ></i>
              </div>
            </a>
          </div>
        </div>
      </div>
    );
}
