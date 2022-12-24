namespace Lab8
{
    
    public class Camera
    {
        public Point3D cameraPosition;
        public Vector cameraDirection;
        public Vector cameraUp;
        public Vector cameraRight;

        double yaw = 0.0; 
        double pitch = 0.0;

        public Camera()
        {
            cameraPosition = new Point3D(-10, 0, 0);
            cameraDirection = new Vector(1, 0, 0);
            cameraUp = new Vector(0, 0, 1);
            cameraRight = Vector.MultiplyVectors(cameraDirection, cameraUp).normalize();
        }

        public void Move(double leftright = 0, double forwardbackward = 0, double updown = 0)
        {
            cameraPosition.Xf += leftright * cameraRight.x + forwardbackward * cameraDirection.x + updown * cameraUp.x;
            cameraPosition.Yf += leftright * cameraRight.y + forwardbackward * cameraDirection.y + updown * cameraUp.y;
            cameraPosition.Zf += leftright * cameraRight.z + forwardbackward * cameraDirection.z + updown * cameraUp.z;
        }

        public Point3D ToCameraView(Point3D p)
        {
            return new Point3D(
                cameraRight.x * (p.Xf - cameraPosition.Xf) + cameraRight.y * (p.Yf - cameraPosition.Yf) +
                cameraRight.z * (p.Zf - cameraPosition.Zf),
                cameraUp.x * (p.Xf - cameraPosition.Xf) + cameraUp.y * (p.Yf - cameraPosition.Yf) +
                cameraUp.z * (p.Zf - cameraPosition.Zf),
                cameraDirection.x * (p.Xf - cameraPosition.Xf) + cameraDirection.y * (p.Yf - cameraPosition.Yf) +
                cameraDirection.z * (p.Zf - cameraPosition.Zf));
        }

        private double ClampDouble (double value, double min, double max)
        {
            if (min <= value && value <= max) {
                return value;
            }else if (value < min) {
                return min;
            }
            else if (value > max) {
                return max;
            }
            else {
                return double.NaN;
            }
        }

        public void ChangeView(double shiftX = 0, double shiftY = 0)
        {
            var newPitch = ClampDouble(pitch + shiftY, -89.0, 89.0);
            var newYaw = (yaw + shiftX) % 360;
            if (newPitch != pitch)
            {
                AffineTransformations.RotateVectors(ref cameraDirection, ref cameraUp, (newPitch - pitch), cameraRight);
                pitch = newPitch;
            }

            if (newYaw != yaw)
            {
                AffineTransformations.RotateVectors(ref cameraDirection, ref cameraRight, (newYaw - yaw), cameraUp);
                yaw = newYaw;
            }
        }
    }
}