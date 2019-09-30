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
        /// Rotates the 2D transforms so the right vector points at worldPosition
        /// </summary>
        /// <param name="transform">The transform that should to look at</param>
        /// <param name="worldPosition">Point to look at</param>
        public static void LookAt2D(this Transform transform, Vector2 worldPosition)
        {
            Vector2 diff = worldPosition - new Vector2(transform.position.x, transform.position.y);
            diff.Normalize();

            float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        }
    }
}
