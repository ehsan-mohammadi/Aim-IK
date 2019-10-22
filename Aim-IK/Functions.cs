using UnityEngine;

namespace AimIK.Functions
{
    public static class AimIKFunctions
    {
        /// <summary>
        /// Clamp the angle between min and max
        /// </summary>
        /// <param name="angle">The input angle</param>
        /// <param name="min">The min angle</param>
        /// <param name="max">The max angle</param>
        /// <returns>The clamped angle</returns>
        public static float ClampAngle(float angle, float min, float max)
        {
            // Normalize the angle
            angle = NormalizeAngle(angle);

            // Set angle to correct values
            if (angle > 180)
                angle -= 360;
            else if (angle < -180)
                angle += 360;

            // Normalize the min
            min = NormalizeAngle(min);

            // Set min to correct values
            if (min > 180)
                min -= 360;
            else if (min < -180)
                min += 360;

            // Normalize the max
            max = NormalizeAngle(max);

            // Set max to the correct values
            if (max > 180)
                max -= 360;
            else if (max < -180)
                max += 360;

            return Mathf.Clamp(angle, min, max);
        }

        /// <summary>
        /// If the angle over 360 or under 360 degree, then normalize them
        /// </summary>
        /// <param name="angle">The input angle</param>
        /// <returns>The normalized angle</returns>
        private static float NormalizeAngle(float angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;

            return angle;
        }

        /// <summary>
        /// Rotates the 3D transforms so the forward vector points at worldPosition
        /// </summary>
        /// <param name="transform">The transform that should to look at</param>
        /// <param name="worldPosition">Point to look at</param>
        /// <param name="rotationOffset">Rotation offset</param>
        public static void LookAt3D(this Transform transform, Vector3 worldPosition, Vector3 rotationOffset)
        {
            Vector3 targetPos = new Vector3();

            // If rotationOffset equal to 0 or not
            if(rotationOffset != Vector3.zero)
            {
                Vector3 rad = rotationOffset * Mathf.Deg2Rad;

                float[,] rotationMatrix = new float[3, 3];
                rotationMatrix[0, 0] = Mathf.Cos(rad.y) * Mathf.Cos(rad.z);
                rotationMatrix[0, 1] = Mathf.Cos(rad.x) * Mathf.Sin(rad.z) + Mathf.Sin(rad.x) * Mathf.Sin(rad.y) * Mathf.Cos(rad.z);
                rotationMatrix[0, 2] = Mathf.Sin(rad.x) * Mathf.Sin(rad.z) - Mathf.Cos(rad.x) * Mathf.Sin(rad.y) * Mathf.Cos(rad.z);
                rotationMatrix[1, 0] = -Mathf.Cos(rad.y) * Mathf.Sin(rad.z);
                rotationMatrix[1, 1] = Mathf.Cos(rad.x) * Mathf.Cos(rad.z) - Mathf.Sin(rad.x) * Mathf.Sin(rad.y) * Mathf.Sin(rad.z);
                rotationMatrix[1, 2] = Mathf.Sin(rad.x) * Mathf.Cos(rad.z) + Mathf.Cos(rad.x) * Mathf.Sin(rad.y) * Mathf.Sin(rad.z);
                rotationMatrix[2, 0] = Mathf.Sin(rad.y);
                rotationMatrix[2, 1] = -Mathf.Sin(rad.x) * Mathf.Cos(rad.y);
                rotationMatrix[2, 2] = Mathf.Cos(rad.x) * Mathf.Cos(rad.y);

                targetPos = new Vector3(
                    rotationMatrix[0, 0] * worldPosition.x + rotationMatrix[0, 1] * worldPosition.y + rotationMatrix[0, 2] * worldPosition.z
                    , rotationMatrix[1, 0] * worldPosition.x + rotationMatrix[1, 1] * worldPosition.y + rotationMatrix[1, 2] * worldPosition.z
                    , rotationMatrix[2, 0] * worldPosition.x + rotationMatrix[2, 1] * worldPosition.y + rotationMatrix[2, 2] * worldPosition.z
                    );
            }
            else
            {
                targetPos = worldPosition;
            }

            transform.LookAt(targetPos);
        }

        /// <summary>
        /// Rotates the 2D transforms so the right vector points at worldPosition
        /// </summary>
        /// <param name="transform">The transform that should to look at</param>
        /// <param name="worldPosition">Point to look at</param>
        /// <param name="rotationOffset">Rotation offset</param>
        public static void LookAt2D(this Transform transform, Vector2 worldPosition, float rotationOffset)
        {
            Vector2 diff = worldPosition - new Vector2(transform.position.x, transform.position.y);
            diff.Normalize();

            float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + rotationOffset);
        }
    }
}
