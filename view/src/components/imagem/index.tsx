import { Box, Typography } from "@mui/material";
import { useState } from "react";
import IconifyIcon from "../icon";

const Imagem = ({
  width,
  height,
  boxShadow,
  borderRadius,
  imageSrc,
}: {
  width?: any;
  height?: any;
  boxShadow?: number;
  borderRadius?: number;
  imageSrc: string;
}) => {
  let img = new Image();
  img.src = imageSrc;

  let [loadImage, setLoadImage] = useState<boolean>(true);

  img.onerror = () => {
    setLoadImage(false);
  };
  img.onload = () => {
    setLoadImage(true);
  };
  if (loadImage)
    return (
      <Box
        sx={{
          width,
          height,
          background: `url(${imageSrc})`,
          backgroundSize: "cover",
          backgroundPosition: "center",
        }}
        boxShadow={boxShadow}
        borderRadius={borderRadius}
      />
    );
  else
    return (
      <Box
        sx={{ width: width || 150, height: height || 150 }}
        boxShadow={2}
        borderRadius={borderRadius}
        bgcolor=""
        display={"flex"}
        justifyContent={"center"}
        alignItems={"center"}
      >
        <IconifyIcon icon="pepicons-pencil:photo-off" fontSize={100} />
      </Box>
    );
};

export default Imagem;
