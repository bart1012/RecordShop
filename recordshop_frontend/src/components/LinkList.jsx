import { Children } from "react";

const LinkList = (props) => {
  return (
    <div>
      <h1 className="text-xl font-bold mb-2">{props.title}</h1>
      <ul className="border">
        {Children.map(props.children, (child) => (
          <li className="border-b-1">{child}</li>
        ))}
      </ul>
    </div>
  );
};

export default LinkList;
