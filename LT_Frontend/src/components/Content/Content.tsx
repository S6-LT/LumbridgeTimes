import React, { ReactNode } from "react";

type ContentProps = {
  readonly children: ReactNode;
};

function Content({ children }: ContentProps): JSX.Element {
  return <div className="content">{children}</div>;
}

export default Content;
