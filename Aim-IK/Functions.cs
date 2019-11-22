using UnityEngine;

namespace AimIK.Functions
{
    using Properties;

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
            Vector3 diff = worldPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(diff);

            transform.rotation = rotation * Quaternion.Euler(rotationOffset);
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

        /// <summary>
        /// Check the 3D clamp
        /// </summary>
        /// <param name="part">The input part transform</param>
        /// <param name="limitRotation">The input limit rotation</param>
        /// <param name="rotation">The input rotation</param>
        public static void CheckClamp3D(this Transform part, LimitRotation limitRotation, Rotation rotation)
        {
            // Clamp (If activate)
            if (limitRotation.x.active)
                rotation.x = AimIKFunctions.ClampAngle(part.localEulerAngles.x, limitRotation.x.min, limitRotation.x.max);
            else
                rotation.x = part.localEulerAngles.x;

            if (limitRotation.y.active)
                rotation.y = AimIKFunctions.ClampAngle(part.localEulerAngles.y, limitRotation.y.min, limitRotation.y.max);
            else
                rotation.y = part.localEulerAngles.y;

            if (limitRotation.z.active)
                rotation.z = AimIKFunctions.ClampAngle(part.localEulerAngles.z, limitRotation.z.min, limitRotation.z.max);
            else
                rotation.z = part.localEulerAngles.z;

            // Set rotation variables to part rotation
            Vector3 partRotation = new Vector3(rotation.x, rotation.y, rotation.z);
            part.localEulerAngles = partRotation;
        }

        /// <summary>
        /// Check the 2D clamp
        /// </summary>
        /// <param name="part">The input part transform</param>
        /// <param name="limitRotation">The input axis limit rotation</param>
        /// <param name="rotation">The input 2D rotation</param>
        public static void CheckClamp2D(this Transform part, AxisLimitRotation limitRotation, float rotation)
        {
            // Clamp (If activate)
            if (limitRotation.active)
                rotation = AimIKFunctions.ClampAngle(part.localEulerAngles.z, limitRotation.min, limitRotation.max);
            else
                rotation = part.localEulerAngles.z;

            // Set rotation variables to part rotation
            Vector3 partRotation = new Vector3(part.localEulerAngles.x, part.localEulerAngles.y, rotation);
            part.localEulerAngles = partRotation;
        }
    }
}
