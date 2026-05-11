## Detailed Registry Execution Plan

### Storage layout

- A configured multi-registry storage root in the local filesystem (default path is `registry/`).
- A configured symlink maps to `registry/registry.terraform.io/` -> `registry/terraform/`.
- The Terraform `RegistryService` expects terraform registry storage in the `/terraform/` subfolder.

Under the configured storage path, the service should expect:

- `/terraform/providers/` as a symlink to `plugins/`
- `/terraform/plugins/` for provider/plugin artifacts
- `/terraform/modules/` for module artifacts

This keeps Terraform protocol compatibility while using a generic `plugins/` implementation folder.

### Abstract behavior

- The service discovers registries under the configured storage root.
- For Terraform, it scans `/terraform/plugins/` and `/terraform/modules/`.
- Provider/plugin namespaces and versions are indexed from the filesystem hierarchy.
- Module namespaces and versions are indexed from the filesystem hierarchy.
- The `/v1/providers/...` and `/v1/modules/...` endpoints remain stable for clients.

### Compatibility rules

- Keep the `/providers/` path available through the symlink so existing Terraform clients continue to work.
- Use `plugins/` for the main repository layout to support future registry types.
- Keep module storage under `modules/` adjacent to `plugins/`.

### Testing strategy

- Validate Storage layout under symlink `registry/registry.terraform.io/` -> `registry/terraform/`.
- Verify provider and module indexes are populated from the correct storage paths.
- Verify `/v1/providers/.../versions` and `/v1/modules/.../versions` responses.
- Verify download URLs resolve to storage paths under `/terraform/providers/...`.
- Ensure future registry roots can be added with the same pattern.

